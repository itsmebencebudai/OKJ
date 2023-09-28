# 2-14sz
OraiMunka
1. fontos, hogy jó mappában legyünk
2. git add .
3. git commit -m "hol történt változás"
*git push local main*
4. git push origin main
*"token code"-ot kéri majd amit létre kell hozni a github oldalon*


új mappából új fájl a git repohoz való hozzáadás:
1. git init
2. git add .
3. git commit -m "index inicializálva html5"
  *git push origin main-t most nem lehet használni - meg kell mondani, hova szeretném bekötni ezt a lokális depository-t*
  *ezt meg lehet adni, ha a következő kódot hasznűljuk*
4. git remote add origin "github code részből a linket kimásoljuk"
5. git push origin master *azért nem lehet master helyett main-t használni, mert lokális depositoryban voltunk!!!*
   *ezt egybéként meg lehet nézni a "git branch" paranccsal*
   *"git branch -m main" modify-olom és master helyett mostmár main lesz, ezt újra tudjuk ellenőrizni a "get branch" paranccsal*
   *"git fetch origin master"*
   *"git merge master"*

--------------------GIT-TERMINAL COMMANDS--------------------
1. git clone https://github.com/accountname/projectname =====> Leklónozod a depository-t abba a mappába, amelyikben éppen vagy a terminálon belül.
2. git add . =====> ???
3. git init =====> ???
4. git checkout -b "name" =====> Egy új branch ág létrehozása.
5. git commit -m "something" =====> Commenteled, hogy mit változtattál.
6. git push origin main =====> ???
7. git push origin "branch name" =====> ???
8. git remote add origin "https://github.com/youraccount/projectname" =====> ???
9. git log =====> ???
10. git status =====> Látjuk, hogy melyik ágon vagyunk.
11. git remote set-url origin https://username:token@github.com/username/repository.git =====> ???
12. git branch =====> Ellenőrizni tudjuk az águnk jelenlegi jogosultságát.
13. git branch -m main =====> Modify-olod a branch ág jogosultságát és master helyett mostmár main lesz.
14. git fetch origin master =====> ???
15. git merge master =====> ???
16. git pull origin "branch name" =====> Egy branch ág lehúzása.
17. git merge main origin/main =====> ???
18. git diff =====> ???
19. git checkout -d "branch name"=====> Ha már merge-elve volt az ág

--------------------TERMINAL COMMANDS--------------------
1. ls =====> A jelenlegi könyvtárban lévő fájlok és mappákat tudjuk kilistázni vele.
2. cd /folder you want to go to/ =====> Könyvtárak között tudunk vele lépkedni.
3. cd.. =====> Visszalépés a jelenlegi könyvtárból a följebb lévő könyvtárba.
4. mkdir "folder name" =====> Egy új mappa létrehozása.
5. rmdir "folder name" =====> Egy bizonyos mappa törlése.
6. open "File.name" =====> Fájl megnyitása.
