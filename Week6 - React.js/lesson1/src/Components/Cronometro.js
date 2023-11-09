import React, {useEffect, useState} from 'react';

const Cronometro = () => {
  const time = 0;
  const eButtons = {
    fn_reset: () => {
      setCronometro(time)
    },
    fn_start: () => {
      setRunning(true)
    },
    fn_stop: (interval) => {
      setRunning(false)
    },
  }
  const [cronometro, setCronometro] = useState(time);
  const [running, setRunning] = useState(false);

  useEffect(() => {
    let interval
    if (!running) {
      clearInterval(interval);
    } else {
      interval = setInterval(() => setCronometro(current => current + 10), 10);
    }
    return () => clearInterval(interval);
  }, [running]);

  return (<div>
    <h2>Cronometro</h2>
    <div className="numbers">
      <span>{("0" + Math.floor((cronometro / 60000) % 60)).slice(-2)}:</span>
      <span>{("0" + Math.floor((cronometro / 1000) % 60)).slice(-2)}:</span>
      <span>{("0" + ((cronometro / 10) % 100)).slice(-2)}</span>
    </div>
    <button onClick={eButtons.fn_start}>Start</button>
    <button onClick={eButtons.fn_stop}>Stop</button>
    <button onClick={eButtons.fn_reset}>Reset</button>
  </div>);
};


export default Cronometro;