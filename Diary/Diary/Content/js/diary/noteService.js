NoteService = function () {
    var urls = {
        delete: "Note/Delete",
        setStatus: "Note/SetStatus"
    };

    function deleteNote(id, onSuccess, onFail) {
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
    }

    function setStatus(id, status, onSuccess, onFail) {
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
    }

    function getCreateForm(type ,onSuccess, onFail) {
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
    }

    function createNote(type, dataString, onSuccess, onFail) {
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
    }

    function getUpdateForm(type, id, onSuccess, onFail) {
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
    }

    function updateNote(type, dataString, onSuccess, onFail) {
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
    }

    return {
        deleteNote: deleteNote,
        setStatus: setStatus,
        getCreateForm: getCreateForm,
        createNote: createNote,
        getUpdateForm: getUpdateForm,
        updateNote: updateNote,
    };
}