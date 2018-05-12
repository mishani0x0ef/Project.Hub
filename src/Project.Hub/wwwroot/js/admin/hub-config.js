class HubConfigEditor {
    constructor(editorId) {
        this.editor = ace.edit(editorId);
        this.isValid = true;
 
        this._configureEditor(this.editor);
        this._enableSave();
    }

    enableFullScreenSupport() {
        const expandButtons = document.querySelectorAll(".editor-container .btn-expand");
        expandButtons.forEach(b => b.addEventListener("click", (e) => {
            event.currentTarget.parentElement.classList.add("full-screen");
            this.editor.resize();
        }));

        const collapseButtons = document.querySelectorAll(".editor-container .btn-collapse");
        collapseButtons.forEach(b => b.addEventListener("click", (e) => {
            event.currentTarget.parentElement.classList.remove("full-screen");
            this.editor.resize();
        }));
    }

    saveHubConfiig() {
        const text = this.editor.getValue();
        const promise = $.ajax({
            method: "POST",
            url: "admin/saveHubConfig",
            contentType: "application/json",
            data: JSON.stringify(text)
        });

        promise
            .then(() => this.showSaveSuccess())
            .catch(() => this.showSaveError());
    }

    showSaveSuccess() {
        // todo: implement show of success.
        alert("Success");
    }

    showSaveError() {
        // todo: implement show of error.
        alert("Error");
    }

    _configureEditor(editor) {
        editor.setTheme("ace/theme/monokai");
        editor.session.setMode("ace/mode/json");

        editor.setOptions({
            showPrintMargin: false,
        });

        editor.getSession().on("changeAnnotation", (e) => this._onTextChanged());
    }

    _enableSave() {
        const saveButton = document.getElementById("btn-hub-config-save");
        saveButton.addEventListener("click", () => this.saveHubConfiig());
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