mergeInto(LibraryManager.library, {
    IsWebGLMobile: function () {
        return UnityLoader.SystemInfo.mobile;
    }
});
