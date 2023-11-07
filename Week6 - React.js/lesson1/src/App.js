import React, {useState, useEffect} from 'react';
import Clock from './Components/clock.js';

const App = () => {
    const fromDatabase = [
        {name: 'Italia', timezone: '2'},
        {name: 'Messico', timezone: '6'},
        {name: 'India', timezone: '-5'}
    ];

    const [countries] = useState(fromDatabase);
    const [currentIndex, setCurrentIndex] = useState(0);

    useEffect(() => {
        const interval = setInterval(() => {
            setCurrentIndex(Math.floor(countries.length * Math.random()));
        }, 200);

        return () => clearInterval(interval);
    }, [countries]);

    return (
        <div>
            <h1>Esercizio Clock</h1>
            <Clock country={countries[currentIndex].name} timezone={countries[currentIndex].timezone}/>
        </div>
    );
};

export default App;
