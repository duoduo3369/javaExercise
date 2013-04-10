function openChildWindow(URL) {
    var win = window
            .open(
                    URL,
                    'newwindow',
                    'height=400,width=400,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
    win.focus();
    return win;
}
function dismissChildWindow(win) {
    win.close();
}