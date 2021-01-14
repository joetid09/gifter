export const currentDate = () => {
    const today = new Date
    const month = addZero(today.getMonth() + 1);
    const year = today.getFullYear();
    const date = today.getDate();
    //Time portion
    let timePeriod = "AM"
    let hour = today.getHours();
    if (hour > 12) {
        hour = `0${hour - 12}`;
        timePeriod = "PM"
    }
    const minute = addZero(today.getMinutes());
    const seconds = addZero(today.getSeconds());

    const todaysDate = `${year}-${month}-${date}T${hour}:${minute}:${seconds}`
    return todaysDate
}

const addZero = (dateItem) => {
    return dateItem < 10 ? `0${dateItem}` : dateItem
}