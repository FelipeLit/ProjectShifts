const btnAttend = document.querySelector("#btnAttend");

const audioAttend = new Audio("../assets/AttendSound.mp3");

console.log(btnAttend);
// console.log(audioAttend);

btnAttend.addEventListener("click", () => {
    audioAttend.play();
});