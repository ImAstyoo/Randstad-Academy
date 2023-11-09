import {useEffect, useState} from 'react';

function FotoAlbum() {
  const photosUrl = 'https://jsonplaceholder.typicode.com/photos';
  const albumsUrl = 'https://jsonplaceholder.typicode.com/albums';
  const usersUrl = 'https://jsonplaceholder.typicode.com/users';

  const [foto, setFoto] = useState([]);
  const [album, setAlbum] = useState([]);
  const [utenti, setUtenti] = useState([]);

  const [utenteSelezionato, setUtenteSelezionato] = useState(0);
  const [albumSelezionato, setAlbumSelezionato] = useState(0);

  useEffect(() => {
    const getFoto = async () => {
      const url = albumSelezionato ? `${photosUrl}'?albumId='${albumSelezionato}` : photosUrl;
      const foto = await fetch(url).then(res => res.json());
      setFoto(foto.slice(0, 10));
    }
    getFoto();
  }, [albumSelezionato]);

  useEffect(() => {
    const getAlbum = async () => {
      const url = utenteSelezionato ? `${albumsUrl}'?userId='${utenteSelezionato}` : albumsUrl;
      const albums = await fetch(url).then(res => res.json());
      setAlbum(albums);
    }
    if(utenteSelezionato) getAlbum();
    return () => {
      setAlbum(0);
    }
  }, [utenteSelezionato]);

  useEffect(() => {
    const getUtenti = async () => {
      const users = await fetch(usersUrl).then(res => res.json());
      setUtenti(users);
    }
    getUtenti();
  }, []);


  return (<div>
    <select onChange={utente => setUtenteSelezionato(utente.target.value)}>
      <option value={0}>Seleziona un utente</option>
      {utenti.map(utente => <option key={utente.id} value={utente.id}>{utente.name}</option>)}
    </select>
    <select onChange={album => setAlbumSelezionato(album)}>
      <option value={0}>Seleziona un album</option>
      {album.map(album => <option key={album.id} value={album.id}>{album.title}</option>)}
    </select>
    <div>
      {foto.map(foto => <img key={foto.id} src={foto.thumbnailUrl} alt={foto.title}/>)}
    </div>
  </div>);
}

export default FotoAlbum;