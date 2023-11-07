const products = [
    {nome: "Prodotto1", prezzo: 10.99},
    {nome: "Prodotto2", prezzo: 19.99},
    {nome: "Prodotto3", prezzo: 7.99},
];
const formProdotto = document.querySelector("#add-product-form");
ricaricaTabella();
formProdotto.addEventListener("submit", (e) => {
    e.preventDefault();
    const formNome = document.querySelector("#product-name");
    const formPrezzo = document.querySelector("#product-price");
    aggiungiProdotto(formNome.value, formPrezzo);
    ricaricaTabella();
})

function aggiungiProdotto(nome, prezzo) {
    const nuovoProdotto = {nome: nome, prezzo: parseFloat(prezzo)};
    products.push(nuovoProdotto);
}

function ricaricaTabella() {
    for (const prodotto in products) {
        console.log(`Prodotto: ${prodotto.nome}, Prezzo: ${prodotto.prezzo}`);
    }
}