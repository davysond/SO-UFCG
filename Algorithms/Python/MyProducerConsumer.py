from random import randint
from time import sleep

buffer = []  #Lista para armazenamento dos valores gerados;
max_size = 5  #Tamanho máximo do buffer;
inative_c = False  #Flag booleana para ativar/desativar o processo consumidor;
inative_p = False  #Flag booleana para ativar/desativar o processo produtor.


def producer():  #Função que cria um produtor;
  global buffer, max_size, inative_c, inative_p
  if not inative_p:  #Verifica se o processo do produtor está ativo;
    while len(buffer) < max_size:  #Verifica se o buffer não está cheio;
      buffer.append(
        randint(0, 5)
      )  #Caso não esteja, adiciona um valor gerado no intervalo especificado;
      print("O Produtor está produzindo:", buffer)
    else:
      print("O Buffer está cheio:", buffer)
      print(
        "O Produtor ficará inativo até que o buffer esteja com algum espaço vazio..."
      )
      inative_p = True  #Desativa o processo do produtor.
      inative_c = False  #Ativa o processo do consumidor.
      consumer()  #Chama o consumidor.


def consumer():  #Função que cria um consumidor;
  global buffer, max_size, inative_c, inative_p
  if not inative_c:  #Verifica se o processo do produtor está ativo;
    if len(buffer) > 0:  #Verifica se a lista não está vazia;
      del buffer[0]  #Remove o primeiro elemento da lista.
      print("O Consumidor está consumindo:", buffer)
    else:
      print("O Buffer está vazio:", buffer)
      print(
        "O Consumidor ficará inativo até que haja algum produto no buffer...")
      inative_c = True
      inative_p = False
      producer()


while True: #Inicializa as funções com um sleep de 1 segundo para melhorar a visualização do processo.
  producer()
  consumer()
  sleep(1)
