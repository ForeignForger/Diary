NoteService = function () {
    var urls = {
        delete: "Note/Delete"
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

    return {
        deleteNote: deleteNote
    };
}