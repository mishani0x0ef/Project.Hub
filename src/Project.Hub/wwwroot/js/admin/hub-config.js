class HubConfigEditor {
    constructor(editorId) {
        this.editor = ace.edit(editorId);
        this.isValid = true;
 
        this._configureEditor(this.editor);
        this._enableFullScreenSupport();
    }

    _configureEditor(editor) {
        editor.setTheme("ace/theme/monokai");
        editor.session.setMode("ace/mode/json");

        editor.setOptions({
            showPrintMargin: false,
        });

        editor.getSession().on("changeAnnotation", (e) => this._onTextChanged());
    }

    _enableFullScreenSupport() {
        const expandButtons = document.querySelectorAll(".editor-container .btn-expand");
        expandButtons.forEach(button => button.addEventListener("click", (e) => this._onExpandClicked(e)));

        const collapseButtons = document.querySelectorAll(".editor-container .btn-collapse");
        collapseButtons.forEach(button => button.addEventListener("click", (e) => this._onCollapseClicked(e)));
    }

    _onExpandClicked(event) {
        event.currentTarget.parentElement.classList.add("full-screen");
        this.editor.resize();
    }

    _onCollapseClicked(event) {
        event.currentTarget.parentElement.classList.remove("full-screen");
        this.editor.resize();
    }

    _onTextChanged() {
        const annotations = this.editor.getSession().getAnnotations();
        const isValid = annotations.length < 1;

        if (this.isValid === isValid) {
            return;
        }

        this.isValid = isValid;
        const saveButton = document.getElementById("btn-hub-config-save");
        const errorText = document.getElementById("lbl-hub-config-save-error");

        if (isValid) {
            saveButton.classList.remove("disabled");
            errorText.classList.add("invisible");
        } else {
            saveButton.classList.add("disabled");
            errorText.classList.remove("invisible");
        }
    }
}