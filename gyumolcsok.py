import random

tomb_gyumolcs = []

class Gyumolcsok:
    def __init__(self, nev, fajta, ar, db, megjegyzes):
        self.nev = nev
        self.fajta = fajta
        self.ar = ar
        self.db = db
        self.megjegyzes = megjegyzes
    def __str__(self):
        return self.nev + "\t" + self.fajta + "\t" + str(self.ar) + "\t" + str(self.db) + "\t" + self.megjegyzes

def fomenu():
    print("==========   F Ő M E N Ü   ==========")
    print("1. Adatok bekérése")
    print("2. Keresés névre")
    print("3. Legdrágább keresése")
    print("4. Kiratás fájlba")
    print("5. ")
    print("0. Kilépés")
    menu = int(input())
    if menu == 1:
        beker()
    elif menu == 2:
        keres_nevre()
    elif menu == 3:
        keres_legdragabb()
    elif menu == 4:
        fajlba_iratas()
    elif menu == 5:
        fomenu()
    elif menu == 0:
        exit()
    else:
        fomenu()


def beker():
    nev = "a"
    db = 0
    hely_index = 0
    while nev != "":
        nev = input("Kérem a gyümölcs nevét (Üres jelre kilép)! ")
        if nev == "":
            break
        else:
            fajta = input("Kérem a gyümölcs fajtáját (h - honos vagy d - déli)!")
            ar = int(input("Kérem a gyümölcs árát!"))
            db = random.randint(1, 11)
            megjegyzes = honosM(fajta, hely_index)
            gyumolcs = Gyumolcsok(nev, honos(fajta), ar, db, megjegyzes)
            tomb_gyumolcs.append(gyumolcs)
            hely_index = hely_index + 1;
    for i in range(len(tomb_gyumolcs)):
        print(tomb_gyumolcs[i])
    fomenu()


def honos(faj):
    if faj == "h":
        faj_vissza = "honos"
    elif faj == "d":
        faj_vissza = "déli"
    else:
        faj_vissza = "rossz érték"
    return faj_vissza


def honosM(faj, hely):
    tomb_gyumolcs[hely].fajta = faj


def keres_nevre():
    print("==========   K E R E S É S   N É V R E ==========")
    keresett_nev = input("Kérem a keresett gyümölcs nevét! ")
    talalat = "Nincs találat"
    for i in range(len(tomb_gyumolcs)-1):
        if keresett_nev == tomb_gyumolcs[i].nev:
            talalat = "Siker, megvan a gyümölcs!"
            db = i
    print(talalat)
    print(tomb_gyumolcs[db])
    fomenu()

def keres_legdragabb():
    print("==========   L E G D R Á G Á B B   K E R E S É S E ==========")
    hely = 0
    max_ar = 0
    for i in range(len(tomb_gyumolcs) - 1):
        if max_ar < tomb_gyumolcs[i].ar:
            max_ar = tomb_gyumolcs[i].ar
            hely = i
    print("A lágdrágább gyümölcs:")
    print(tomb_gyumolcs[hely])
    fomenu()


def fajlba_iratas():
    print("==========   F Á J L B A   I R A T Á S ==========")
    f = open("gyümi.txt", "w")
    f.writelines(tomb_gyumolcs)
    f.close()



fomenu()