mergeInto(LibraryManager.library, {
    ShowMobileKeyboard: function() {
      var input = document.createElement('input');
      input.setAttribute('type', 'text');
      input.style.opacity = 0;
      input.style.position = 'absolute';
      input.style.pointerEvents = 'none';
      document.body.appendChild(input);
      input.focus();
      input.addEventListener('input', function() {
        var value = input.value;
        input.value = '';
        var stack = Runtime.stackSave();
        var ptr = allocate(intArrayFromString(value), 'i8', ALLOC_STACK);
        Runtime.dynCall('vi', window.MobileKeyboardCallback, [ptr]);
        Runtime.stackRestore(stack);
      });
      input.addEventListener('blur', function() {
        document.body.removeChild(input);
      });
    }
  });
  