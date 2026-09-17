Console.WriteLine("Dijkstra!");

/*
 * 1. Tenho um grafo.
 * 
 * 2. Tenho um início.
 * 
 * 3. A distância do início é 0.
 * 
 * 4. Todas as outras distâncias começam como infinito.
 * 
 * 5. Escolho o vértice não visitado
 *    com menor distância conhecida.
 * 
 * 6. Examino seus vizinhos.
 * 
 * 7. Tento melhorar a distância deles.
 * 
 * 8. Se melhorar:
 *         atualizo a distância
 *         salvo de onde vim.
 * 
 * 9. Marco o vértice como visitado.
 * 
 * 10. Repito.
 * */

// Dado um grafo G(V,E)

// V(G) =
Letras[] Vertices = { Letras.A, Letras.B, Letras.C, Letras.D, Letras.E };

// E(G) =
Arestas[] Arestas =
{
    new(Letras.A, Letras.B, 5),
    new(Letras.A, Letras.C, 1),

    new(Letras.B, Letras.C, 4),
    new(Letras.B, Letras.D, 2),
    new(Letras.B, Letras.E, 4),

    new(Letras.C, Letras.B, 2),
    new(Letras.C, Letras.D, 5),
    new(Letras.C, Letras.E, 5),

    new(Letras.D, Letras.E, 2),
};


// Primeira estrutura que criamos. Essa é a estrutura que armazena os valores dos vértices,
// que inicialmente possuem valores marcados como infinito.
Dictionary<Letras, int> distancia =
    Vertices.ToDictionary(
        v => v,
        v => int.MaxValue
    );

// Essa estrutura armazena os vértices já analisados pelo algoritmo.
HashSet<Letras> Visitados = new HashSet<Letras>();
HashSet<Letras> MenorRota = new HashSet<Letras>();

// Escolhemos um início. Esse modelo atual nos dá a leitura do grafo com a melhor rota partindo do início,
// ou seja, ele não está definido para chegar a um ponto. Esse podemos dar através da leitura do resultado.
Letras Inicio = Letras.A;

// Aqui é uma parte importante. Essa define o valor do vértice inicial,
// ou seja, passando a letra (vértice) que vai receber a distância 0, ou seja, o início.
distancia[Inicio] = 0;


// O algoritmo opera sobre iterações. O uso de um loop é inevitável por vértice analisado.
while (true)
{

    // Verificação básica para pegar a lista de vértices candidatos (ainda não vistos).
    var verticesNaoVistos = distancia
        .Where(v => !Visitados.Contains(v.Key));

    // Se todos foram analisados, pode quebrar o loop.
    if (!verticesNaoVistos.Any())
        break;

    // A escolha do vértice atual é dada por escolha do menor 'd'.
    // Logo, o algoritmo escolhe o vértice não visitado de menor distância conhecida.
    var verticeAtual =
        verticesNaoVistos.MinBy(v => v.Value);

    // A ordem em que Dijkstra determinou os vértices em ordem crescente de distância definitiva.
    MenorRota.Add(verticeAtual.Key);

    // Esse loop é o que faz o algoritmo brilhar, pois o algoritmo escolhe sempre a melhor rota para cruzar o grafo,
    // mas, para saber o valor dos demais vértices, temos um loop que roda no meio do trajeto do vértice escolhido,
    // analisando o peso das arestas e os vizinhos conectados a ele.
    foreach (var arestaAdjacente in Arestas.Where(a => a.Inicio == verticeAtual.Key))
    {
        // Faz a soma da distância do vértice atual + a distância para chegar no vértice vizinho.
        // Aqui ele já é somado com o valor percorrido até agora pelo vértice atual.
        var distanciaVizinha = verticeAtual.Value + arestaAdjacente.Distancia;

        // Ao descobrir, salvamos o valor encontrado para o vértice vizinho através desse vértice analisado.
        var valorVerticeVizinho = distancia[arestaAdjacente.Fim];

        // Com essa informação, podemos ajustar as rotas, mostrando que podem existir rotas melhores
        // para um determinado nó vizinho que ainda não exploramos.
        if (distanciaVizinha < valorVerticeVizinho)
        {
            distancia[arestaAdjacente.Fim] = distanciaVizinha;
        }
    }

    // Após completarmos a vistoria sobre um vértice, nós adicionamos ele à lista dos já visitados.
    Visitados.Add(verticeAtual.Key);
}

string result = "";

foreach (var v in MenorRota)
{
    result += string.Join("", v.ToString());
}

Console.WriteLine(result);

public struct Arestas(Letras Inicio, Letras Fim, int distancia)
{
    public Letras Inicio = Inicio;
    public Letras Fim = Fim;
    public int Distancia = distancia;
}

public enum Letras
{
    A, B, C, D, E, F, G, H, I, J
}

