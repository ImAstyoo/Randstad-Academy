import React, {useState, useEffect} from 'react';

const Clock = ({country, timezone}) => {
    const offset = parseInt(timezone) * 3600000;
    const [time, setTime] = useState(new Date());
    const adjustedTime = new Date(time.getTime() + offset);
    const eTime = {
        hours: adjustedTime.getHours().toString().padStart(2, '0'),
        minutes: adjustedTime.getMinutes().toString().padStart(2, '0'),
        seconds: adjustedTime.getSeconds().toString().padStart(2, '0'),
    };


    useEffect(() => {
        const interval = setInterval(() => {
            setTime(new Date());
        }, 1000);

        return () => clearInterval(interval);
    }, []);

    return (
        <div>
            <h2>{country}</h2>
            <div>
                {eTime.hours}:{eTime.minutes}:{eTime.seconds}
            </div>
        </div>
    );
};


export default Clock;