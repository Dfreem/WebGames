
export function initKeyboardListener(keyboardListener) {
    console.log('registering keyboard listener');
    window.addEventListener('keydown', (e) => {
        console.log(e);
        if (e.key === 'ArrowLeft') {
            keyboardListener.invokeMethodAsync('Left');
        }
        if (e.key === 'ArrowRight') {
            keyboardListener.invokeMethodAsync('Right');
        }
        if (e.key === 'ArrowDown') {
            keyboardListener.invokeMethodAsync('Down');
        }
        if (e.key === 'ArrowUp') {
            keyboardListener.invokeMethodAsync('Up');
        }
    })

}
