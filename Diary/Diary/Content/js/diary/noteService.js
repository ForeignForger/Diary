NoteService = function () {
    var urls = {
        delete: "Note/Delete",
        setStatus: "Note/SetStatus"
    };

    this.deleteNote = function(id, onSuccess, onFail) {
        $.ajax({
            url: urls.delete,
            type: "GET",
            data: {
                noteId: id
            },
            success: function (response) {
                onSuccess(response);
            },
            error: function () {
                onFail();
            }
        });
    };

    this.setStatus = function(id, status, onSuccess, onFail) {
        $.ajax({
            url: urls.setStatus,
            type: "GET",
            data: {
                noteId: id,
                status: status
            },
            success: function (response) {
                onSuccess(response);
            },
            error: function () {
                onFail();
            }
        });
    };

    this.getCreateForm = function(type, onSuccess, onFail) {
        $.ajax({
            url: type + "/Create",
            type: "GET",
            success: function (response) {
                onSuccess(response);
            },
            error: function () {
                onFail();
            }
        });
    };

    this.createNote = function(type, dataString, onSuccess, onFail) {
        $.ajax({
            url: type + "/Create",
            type: "POST",
            data: dataString,
            success: function (response) {
                onSuccess(response);
            },
            error: function () {
                onFail();
            }
        });
    };

    this.getUpdateForm = function(type, id, onSuccess, onFail) {
        $.ajax({
            url: type + "/Update",
            data: {
                id: id,
            },
            type: "GET",
            success: function (response) {
                onSuccess(response);
            },
            error: function () {
                onFail();
            }
        });
    };

    this.updateNote = function(type, dataString, onSuccess, onFail) {
        $.ajax({
            url: type + "/Update",
            type: "POST",
            data: dataString,
            success: function (response) {
                onSuccess(response);
            },
            error: function () {
                onFail();
            }
        });
    };
};