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

    return {
        deleteNote: deleteNote,
        setStatus: setStatus
    };
}