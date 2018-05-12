class HubConfigEditor {
    constructor(editorSelector) {
        this.codeEditor = new CodeEditor(editorSelector, (text) => this.saveHubConfiig(text));

        this.codeEditor.enableFullScreenSupport();
    }

    saveHubConfiig(text) {
        return $.ajax({
            method: "POST",
            url: "admin/saveHubConfig",
            contentType: "application/json",
            data: JSON.stringify(text)
        });
    }
}