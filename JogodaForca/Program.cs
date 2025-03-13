namespace JogodaForca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool denovo = true;
            while (denovo)
            {

                string[] palavras =

               {
           "CACHORRO",
           "GATO",
           "ELEFANTE",
           "LEAO",
           "TIGRE",
           "URSO",
           "COBRA",
           "MACACO",
           "GIRAFA",
           "ZEBRA",
           "LOBO",
           "RINOCERONTE",
           "HIPOPOTAMO",
           "CAVALO",
           "JACARE",
           "CANGURU",
           "PANDA",
           "TAMANDUA",
           "PATO",
           "GALO",
           "ARARA",
           "TUCANO",
           "BALEIA",
           "GOLFINHO",
           "PAVAO"
           };

                Random geradorNuneros = new Random();

                int indiceEscolhido = geradorNuneros.Next(palavras.Length);

                string palavraMagica = palavras[indiceEscolhido];

                //['_''_''_''_'...]
                char[] letrasEncontradas = new char[palavraMagica.Length];

                for (int caractereAtual = 0; caractereAtual < letrasEncontradas.Length; caractereAtual++)
                {
                    letrasEncontradas[caractereAtual] = '_';
                }

                int quantidadedeErros = 0;
                bool jogadorGanhou = false;
                bool jogadorPerdeu = false;


                do
                {

                    //operador ternário
                    string letrasEncontradasCompleta = string.Join(" ", letrasEncontradas);

                    string cabecaDoDesenho = quantidadedeErros >= 1 ? " O " : "  ";
                    string troncoDoDesenho = quantidadedeErros >= 2 ? "x" : " ";
                    string troncoInferiorDoDesenho = quantidadedeErros >= 2 ? " x" : " ";
                    string bracoEsquerdoDoDesenho = quantidadedeErros >= 3 ? "/" : " ";
                    string bracoDireitoDoDesenho = quantidadedeErros >= 4 ? "\\" : " ";
                    string PernasDoDesenho = quantidadedeErros >= 5 ? "/ \\" : " ";



                    Console.Clear();
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("Jogo da Forca");
                    Console.WriteLine("DICA: ANIMAL");
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine(" ___________        ");
                    Console.WriteLine(" |/        |        ");
                    Console.WriteLine(" |        {0}          ", cabecaDoDesenho);
                    Console.WriteLine(" |        {0}{1}{2} ", bracoEsquerdoDoDesenho, troncoDoDesenho, bracoDireitoDoDesenho);
                    Console.WriteLine(" |        {0}        ", troncoInferiorDoDesenho);
                    Console.WriteLine(" |        {0}         ", PernasDoDesenho);
                    Console.WriteLine(" |                  ");
                    Console.WriteLine(" |                  ");
                    Console.WriteLine("_|____              ");
                    Console.WriteLine("PALAVRA: " + letrasEncontradasCompleta);
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("Erros do Jogador: " + quantidadedeErros);
                    Console.WriteLine("----------------------------------------------------");

                    //dado um caractere
                    Console.Write("\nDigite uma letra válida: ");
                    string entradaInicial = Console.ReadLine()!.ToUpper();

                    bool letraFoiEncontrada = false;

                    if (entradaInicial.Length > 1)
                    {
                        Console.WriteLine("\nInforme apenas UM caractere.");
                        continue;
                    }

                    char chute = entradaInicial[0];

                    //LÓGICA

                    for (int contadorCaracteres = 0; contadorCaracteres < palavraMagica.Length; contadorCaracteres++)
                    {
                        char caractereAtual = palavraMagica[contadorCaracteres];

                        if (chute == caractereAtual)
                        {
                            letrasEncontradas[contadorCaracteres] = caractereAtual;
                            letraFoiEncontrada = true;
                        }

                    }

                    if (letraFoiEncontrada == false)
                    {
                        quantidadedeErros++;
                    }

                    string palavraEncontradaCompleta = String.Join("", letrasEncontradas); //MELANCIA

                    jogadorGanhou = palavraEncontradaCompleta == palavraMagica;
                    jogadorPerdeu = quantidadedeErros >= 5;

                    if (jogadorGanhou)
                    {
                        Console.Clear();
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine($"Você acertou! Era: {palavraMagica}, parabéns!");
                        Console.WriteLine("----------------------------------------------------");

                    }

                    else if (jogadorPerdeu)
                    {
                        quantidadedeErros = 5;
                        Console.Clear();
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine("Jogo da Forca");
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine(" ___________        ");
                        Console.WriteLine(" |/       |        ");
                        Console.WriteLine(" |        O          ");
                        Console.WriteLine(" |       /x\\        ");
                        Console.WriteLine(" |        x          ");
                        Console.WriteLine(" |       / \\        ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine(" |                  ");
                        Console.WriteLine("_|____              ");
                        Console.WriteLine("PALAVRA: " + letrasEncontradasCompleta);
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine("Erros do Jogador: " + quantidadedeErros);
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine($"Você errou a palavra! Era: {palavraMagica}, TENTE NOVAMENTE!");
                        Console.WriteLine("----------------------------------------------------");
                    }


                }
                while (jogadorGanhou == false && jogadorPerdeu == false);

                Console.WriteLine("Deseja Continuar? (S/N)");
                string continuar = Console.ReadLine().ToLower();

                if (continuar != "s")
                    denovo = false;

            }

                }
            }
}
