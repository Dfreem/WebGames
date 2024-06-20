
export function initKeyboardListener(keyboardListener) {
    window.addEventListener('keydown', (e) => {
        keyboardListener.invokeMethodAsync('GetKey', e.key);
    });

}
