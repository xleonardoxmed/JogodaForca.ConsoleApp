using System.Globalization;

namespace JogodaForca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool denovo = true;
            while (denovo)
            {
               string palavraMagica = Geradores();
               (string letrasEncontradasCompleta, int condicao, int quantidadedeErros) = Formatacao(palavraMagica);

                    if (condicao == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine($"Você acertou! Era: {palavraMagica}, parabéns!");
                        Console.WriteLine("----------------------------------------------------");                     
                    }

                    else if (condicao == -1)
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

                Console.WriteLine("Deseja Continuar? (S/N)");
                string continuar = Console.ReadLine()!.ToLower();

                if (continuar != "s")
                    denovo = false;

            }

          static string Geradores()
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

            Random geradorNumeros = new Random();
            int indiceEscolhido = geradorNumeros.Next(palavras.Length);
            string palavraMagica = palavras[indiceEscolhido];

            return palavraMagica;
        }
          static (string, int, int) Formatacao(string palavraMagica)
        {
            int condicao = 0; // 1 venceu, -1 perdeu
            int quantidadedeErros = 0;
            char[] letrasEncontradas = new char[palavraMagica.Length];
            string letrasEncontradasCompleta = string.Join(" ", letrasEncontradas);
            
            while (condicao == 0)
            {
                for (int caractereAtual = 0; caractereAtual < letrasEncontradas.Length; caractereAtual++)
                {
                    letrasEncontradas[caractereAtual] = '_';
                }

                bool letraFoiEncontrada = false;
               
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

                Console.Write("\nDigite uma letra válida: ");
                string entradaInicial = Console.ReadLine()!.ToUpper();
                char chute = entradaInicial[0];

                while (entradaInicial.Length > 1)
                {
                    Console.WriteLine("\nInforme apenas UM caractere.");
                    entradaInicial = Console.ReadLine()!.ToUpper();
                    continue;
                }


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

                string palavraEncontradaCompleta = String.Join("", letrasEncontradas);

                if (palavraEncontradaCompleta == palavraMagica)
                    condicao = 1;

                if (quantidadedeErros >= 5)
                    condicao = -1;

            }
            return (letrasEncontradasCompleta, condicao, quantidadedeErros);
        }


    }
}
