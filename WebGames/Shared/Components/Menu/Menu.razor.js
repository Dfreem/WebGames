
export function showModal(id) {
    let element = document.getElementById(id);
    const modal = new bootstrap.Modal(element);
    modal.show();
}

export function hideModal(id) {
    let element = document.getElementById(id)
    const modal = new bootstrap.Modal(element);
    modal.hide();
}

export function toggleModal(id) {
    let element = document.getElementById(id)
    const modal = new bootstrap.Modal(element);
    modal.toggle();
}