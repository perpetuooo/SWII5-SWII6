const API_URL = "http://localhost:5009/api/Books";

const addBookForm = document.getElementById("addBookForm");
const booksList = document.getElementById("booksList");
const formTitle = document.getElementById("formTitle");
const bookIdField = document.getElementById("bookId");

window.onload = fetchBooks;

function fetchBooks() {
    fetch(API_URL)
        .then((response) => response.json())
        .then((data) => {
            booksList.innerHTML = "";
            if (data.length === 0) {
                booksList.innerHTML = "<p>Nenhum livro encontrado.</p>";
                return;
            }
            data.forEach((book) => {
                booksList.innerHTML += `
                    <div>
                        <p><strong>${book.title}</strong> por ${book.author} (${book.year || "Ano desconhecido"})</p>
                        <p>ISBN: ${book.isbn || "Não informado"}</p>
                        <button onclick="editBook(${book.id})">Editar</button>
                        <button onclick="deleteBook(${book.id})">Deletar</button>
                    </div>
                    <hr />
                `;
            });
        })
        .catch((error) => console.error("Erro ao buscar livros:", error));
}

addBookForm.onsubmit = (e) => {
    e.preventDefault();

    const title = document.getElementById("title").value;
    const author = document.getElementById("author").value;
    const year = document.getElementById("year").value;
    const isbn = document.getElementById("isbn").value;

    const book = {
        title: title || null,
        author: author || null,
        year: parseInt(year, 10) || null,
        isbn: isbn || null
    };

    const bookId = bookIdField.value;
    const method = bookId ? "PUT" : "POST";
    const url = bookId ? `${API_URL}/${bookId}` : API_URL;

    fetch(url, {
        method: method,
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(book),
    })
        .then((response) => {
            if (response.ok) {
                fetchBooks();
                addBookForm.reset();
                formTitle.textContent = "Adicionar Livro";
                bookIdField.value = "";
            } else {
                response.text().then((msg) => alert(`Erro: ${msg}`));
            }
        })
        .catch((error) => console.error("Erro ao adicionar/editar livro:", error));
};

function editBook(id) {
    fetch(`${API_URL}/${id}`)
        .then((response) => response.json())
        .then((book) => {
            document.getElementById("title").value = book.title;
            document.getElementById("author").value = book.author;
            document.getElementById("year").value = book.year;
            document.getElementById("isbn").value = book.isbn || "";
            bookIdField.value = book.id;

            formTitle.textContent = "Editar Livro";
        })
        .catch((error) => console.error("Erro ao buscar livro para editar:", error));
}

function deleteBook(id) {
    fetch(`${API_URL}/${id}`, { method: "DELETE" })
        .then((response) => {
            if (response.ok) {
                fetchBooks();
            } else {
                alert("Erro ao deletar o livro.");
            }
        })
        .catch((error) => console.error("Erro ao deletar livro:", error));
}
