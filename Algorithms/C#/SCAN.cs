using System;
using System.Collections.Generic;

    class SCANalgorithm
    {

        static int size = 8;
        static int disk_size = 200;

        static void SCAN(int[] arr, int head, String direction)
        {
            int seek_count = 0;
            int distance, cur_track;
            List<int> left = new List<int>(),
                            right = new List<int>();
            List<int> seek_sequence = new List<int>();

            // Acrescentando os valores que devem ser visitados antes do final;
            if (direction == "left")
                left.Add(0);
            else if (direction == "right")
                right.Add(disk_size - 1);

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

            // Executa o loop duas vezes, uma operação à direita e outra à esquerda da cabeça;
            int run = 2;
            while (run-- > 0)
            {
                if (direction == "left")
                {
                    for (int i = left.Count - 1; i >= 0; i--)
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
                    direction = "right";
                }
                else if (direction == "right")
                {
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
                    direction = "left";
                }
            }

            Console.Write("Quantidade Totais de Operações Seek = "
                                + seek_count + "\n");
            Console.Write("Sequência Seek: " + "\n");
            for (int i = 0; i < seek_sequence.Count; i++)
            {
                Console.Write(seek_sequence[i] + "\n");
            }
        }
        public static void Main(String[] args)
        {

            // Vetor de elementos;
            int[] array = { 176, 79, 34, 60,
                    92, 11, 41, 114 };
            int head = 50;
            String direction = "left";

            SCAN(array, head, direction);
        }
    }