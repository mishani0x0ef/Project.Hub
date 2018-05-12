class HubConfigEditor {
    constructor(editorId) {
        this.editor = ace.edit(editorId);
        this._configureEditor(this.editor);
        this._enableFullScreenSupport();
    }

    _configureEditor(editor) {
        editor.setTheme("ace/theme/monokai");
        editor.session.setMode("ace/mode/json");

        editor.setOptions({
            showPrintMargin: false,
        });
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
}