#!/usr/bin/env python
import  mysql.connector
from time import sleep, localtime, strftime
import sys
import RPi.GPIO as GPIO
from mfrc522 import SimpleMFRC522
import os

Odczyt = SimpleMFRC522()

plik = open('IniBaza')
dostep = plik.read()
plik.close()
dostep = dostep.split(' ')

try:
     while True:
       sleep(2)
       k = 0
       idKarty = Odczyt.read_id()
       czas = strftime("%Y-%m-%d %H:%M:%S", localtime())
       if os.system("ping -c 1 212.77.100.101"):
         if os.path.isfile("/home/pi/RCP/odbicia"):
           print(" ")
         else:
           os.system("touch odbicia") 
         plik = open('odbicia','a')
         try:
          wiersz = str(idKarty) + ";" + czas + ";" 
          plik.write(wiersz)
         finally:
          plik.close()
       else:
        
        try:
         baza = mysql.connector.connect(
         host=dostep[0],
         user=dostep[1],
         passwd=dostep[2],
         database=dostep[3]
         )
        except:
         if os.path.isfile("/home/pi/RCP/odbicia"):
           print(" ")
         else:
           os.system("touch odbicia") 
         plik = open('odbicia','a')
         try:
          wiersz = str(idKarty) + ";" + czas + ";" 
          plik.write(wiersz)
         finally:
          plik.close()


        else:
         kursor = baza.cursor()
         kwerenda = ("INSERT INTO odbicia (ID,NrKarty,Czas) VALUES (%s, %s, %s)")
         wiersz = ('',idKarty,czas)
         kursor.execute(kwerenda,wiersz)
        
         if os.path.isfile("/home/pi/RCP/odbicia"):
          plik = open('odbicia')
          plikOdbicia = plik.read()
          plik.close()

          plikOdbicia = plikOdbicia.split(';')
          iloscKrotek = (len(plikOdbicia)-1);
          while k < iloscKrotek:
           idKarty = plikOdbicia[k]
           czas = plikOdbicia[k+1]
           kwerenda = ("INSERT INTO odbicia (ID,NrKarty,Czas) VALUES (%s, %s, %s)")
           wiersz = ('',idKarty,czas)
           kursor.execute(kwerenda,wiersz)   
           k = k +2;

         baza.commit()
         baza.close()
        if k>0:
         os.unlink("/home/pi/RCP/odbicia")
except KeyboardInterrupt:
        GPIO.cleanup()

