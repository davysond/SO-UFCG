using System;
using System.Collections.Generic;

    class C_SCANalgorithm
    {

        static int size = 8;
        static int disk_size = 200;

        static void CSCAN(int[] arr, int head)
        {
            int seek_count = 0;
            int distance, cur_track;

            List<int> left = new List<int>();
            List<int> right = new List<int>();
            List<int> seek_sequence = new List<int>();

            // Adicionando os valores finais antes da direção ser invertida;
            left.Add(0);
            right.Add(disk_size - 1);

            // Elementos a esquerda da cabeça serão atendidas assim que a direção da cabeça voltar para o início;
            for (int i = 0; i < size; i++)
            {
                if (arr[i] < head)
                    left.Add(arr[i]);
                if (arr[i] > head)
                    right.Add(arr[i]);
            }

            // Ordenando os valores de cada vetor, de acordo com sua direção;
            left.Sort();
            right.Sort();

            // Primeiro são atendidas as requisições à direita da cabeça;
            for (int i = 0; i < right.Count; i++)
            {
                cur_track = right[i];

                // Adicionanando a trilha atual para buscar a sequência;
                seek_sequence.Add(cur_track);

                // Calculando a distância absoluta;
                distance = Math.Abs(cur_track - head);

                // Incrementando a distância para a contagem da trilha;
                seek_count += distance;

                // Definindo a track atual como a nova cabeça do vetor;
                head = cur_track;
            }

            // Assim que se chega ao final, volta para o início;
            head = 0;

            // Adicionado a contagem de busca para a cabeça, de 199 até 0;
            seek_count += (disk_size - 1);

            // Agora são atendidas as requisições que sobraram, na direção inversa;
            for (int i = 0; i < left.Count; i++)
            {
                cur_track = left[i];

                // Adicionanando a trilha atual para buscar a sequência;
                seek_sequence.Add(cur_track);

                // Calculando a distância absoluta;
                distance = Math.Abs(cur_track - head);

                // Incrementando a distância para a contagem da trilha;
                seek_count += distance;

                // Definindo a track atual como a nova cabeça do vetor;
                head = cur_track;
            }

            Console.WriteLine("Número total de operações Seek: "
                              + "= " + seek_count);

            Console.WriteLine("Sequência Seek: ");

            for (int i = 0; i < seek_sequence.Count; i++)
            {
                Console.WriteLine(seek_sequence[i]);
            }
        }

        static void Main()
        {

            // Vetor de elementos;
            int[] array = { 176, 79, 34, 60, 92, 11, 41, 114 };
            int head = 50;

            Console.WriteLine("Posição Inicial da Cabeça: "
                              + head);

            CSCAN(array, head);
        }
    }