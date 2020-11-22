Diary = function (mode, diaryContainer, contentContainer) {
    var settings = {
        viewMode: mode,
        filters: {
            from: null,
            to: null,
            noteTypes: []
        },
        diaryContainer: diaryContainer,
        contentContainer: contentContainer,
        url: "Diary/GetDiaryContent"
    };

    var noteService = new NoteService();

    function init() {
        initViewModeSelection();
        initFilters();
        loadDiary();
    }

    function initViewModeSelection() {
        $("#view-mode-select").change(function () {
            var optionSelected = $("option:selected", this);
            var newMode = optionSelected[0].value;
            var oldMode = settings.viewMode;           
            settings.viewMode = newMode;
            loadDiary();

            $(settings.diaryContainer).removeClass(oldMode).addClass(newMode);
        });
    }

    function initFilters() {
        $("#from-date").change(function () {
            var fromDate = $("#from-date")[0].value;
            settings.filters.from = fromDate;
        });

        $("#to-date").change(function () {
            var toDate = $("#to-date")[0].value;
            settings.filters.to = toDate;
        });

        $(".filter-note-type .checkboxes input").change(function () {
            var index = settings.filters.noteTypes.indexOf(this.value);
            if (this.checked) {
                if (index == -1) {
                    settings.filters.noteTypes.push(this.value);
                }            
            }
            else {
                if (index != -1) {
                    settings.filters.noteTypes.splice(index, 1);
                } 
            }
        });

        $(".filter-button").click(function () {
            loadDiary();
        });

    }

    function loadDiary() {
        var data = {
            mode: settings.viewMode,
            from: settings.filters.from,
            to: settings.filters.to,
            noteTypes: settings.filters.noteTypes
        };
        var jsonData = JSON.stringify(data);

        $.ajax({
            url: settings.url,
            type: "POST",
            contentType: "application/json",
            data: jsonData,           
            success: function (response) {
                insertDiaryContent(response)
            },
            error: function () {
                alert("Couldn't change view mode!");
            }
        });
    }

    function insertDiaryContent(html) {
        $(settings.contentContainer).html(html);

        $(".note-delete-button").click(function () {
            var id = $(this).attr("data-id");
            var onSuccess = loadDiary;

            var onFail = function () {
                alert("Couldn't delete note!");
            };

            noteService.deleteNote(id, onSuccess, onFail);
        });

        $(".note-set_status-button").click(function () {
            var id = $(this).attr("data-id");
            var status = $(this).attr("data-status");
            var onSuccess = loadDiary;

            var onFail = function () {
                alert("Couldn't update status!");
            };

            noteService.setStatus(id, status, onSuccess, onFail);
        });
    }

    return {
        init: init
    };
};