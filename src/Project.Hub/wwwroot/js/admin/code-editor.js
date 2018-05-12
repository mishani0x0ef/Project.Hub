class CodeEditor {
    get editorContainer() {
        return document.querySelector(this.editorContainerSelector);
    }

    get editorElement() {
        return this.editorContainer.querySelector(".editor-content");
    }

    get saveButton() {
        return this.editorContainer.querySelector(".btn-save");
    }

    constructor(editorContainerSelector, saveUrl) {
        this.editorContainerSelector = editorContainerSelector;
        this.saveUrl = saveUrl;

        this.editor = ace.edit(this.editorElement);
        this.isValid = true;

        this._configureEditor(this.editor);
        this.saveButton.addEventListener("click", () => this.save());
    }

    save() {
        const text = this.editor.getValue();
        return $.post(this.saveUrl, JSON.stringify(text))
            .then(() => this._showAllert(".alert-success"))
            .fail(() => this._showAllert(".alert-danger"));
    }

    enableFullScreenSupport() {
        const expandBtn = this.editorContainer.querySelector(".btn-expand");
        expandBtn.classList.remove("invisible");
        expandBtn.addEventListener("click", (e) => {
            event.currentTarget.parentElement.classList.add("full-screen");
            this.editor.resize();
        });

        const collapseButton = this.editorContainer.querySelector(".btn-collapse");
        collapseButton.classList.remove("invisible");
        collapseButton.addEventListener("click", (e) => {
            event.currentTarget.parentElement.classList.remove("full-screen");
            this.editor.resize();
        });

        return this;
    }

    _configureEditor(editor) {
        editor.setTheme("ace/theme/monokai");
        editor.session.setMode("ace/mode/json");

        editor.setOptions({
            showPrintMargin: false,
        });

        editor.getSession().on("changeAnnotation", (e) => this._onTextChanged());
    }

    _onTextChanged() {
        const annotations = this.editor.getSession().getAnnotations();
        const isValid = annotations.length < 1;

        if (this.isValid === isValid) {
            return;
        }

        this.isValid = isValid;
        const errorText = this.editorContainer.querySelector(".config-error");

        if (isValid) {
            this.saveButton.classList.remove("disabled");
            errorText.classList.add("hidden");
        } else {
            this.saveButton.classList.add("disabled");
            errorText.classList.remove("hidden");
        }
    }

    _showAllert(selector) {
        const alert = this.editorContainer.querySelector(selector);
        alert.classList.remove("hidden");
        setTimeout(() => {
            alert.classList.add("hidden");
        }, 5000);
    }
}