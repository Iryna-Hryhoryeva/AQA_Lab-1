# AQA_Lab

1.  Fork репозиторий 
    Репозиторий включает в себя ветку **main**, от main - **dev**,  от dev:  
        `-`**LES-1/TASK-1-git-practice**;  
        `-`**LES-2/TASK-2-.Net-basic-operations**;  
        `-`**LES-3/TASK-3-OOP-principles**;  
        `-`**LES-4/TASK-4-classes-objects-and-methods**;  
        `-`**LES-5/TASK-5-arrays-and-collections**;  
        `-`**LES-6/TASK-6-exception-handling**;  
        `-`**LES-7/TASK-7-serialization-and-json**;  
    в данных ветках Вы будете выполнять соответствующее домашнее задание (название ветки соответствует теме лекций).  
    В данной работе нас интересует ветка **LES-1/TASK-1-git-practice**,  от которой созданы **feature/ignore-png-files** и  **feature/ignore-pdf-files**;
2.  Создайте ветку **feature/txt-file** от **LES-1/TASK-1-git-practice** и переключитесь на нее;
3.  Создайте файл ***AQA.txt***;
4.  В файле напишите свое имя и фамилию;
5.  Создайте **commit** с текущими изменениями и выполните операцию **push**;  
	структура commit: Аббревиатура_ветки: краткое описание изменения.  
	***T1: Created .txt file***
6.  Переключитесь на ветку **feature/ignore-png-files**;  
    В ветке содержится папка ***“Files”***
7.  Создайте файл  **.gitignore**, игнорирующий файлы с расширением ***.png***;
8.  Создайте **commit** с текущими изменениями и выполните операцию **push**;
9.  Переключитесь на ветку **feature/ignore-pdf-files**;  
    В ветке содержится папка ***“Files”***
10. Создайте файл  **.gitignore**, игнорирующий файлы с расширением ***.pdf***;
11. Создайте **commit** с текущими изменениями и выполните операцию **push**;
12. Добавьте изменение из **feature/ignore-pdf-files** в **feature/ignore-png-files** с помощью команды **rebase**, затем **push**;
13. Переключитесь на ветку **feature/txt-file**;
14. В файле напишите текущую дату;
15. Создайте **commit** с текущими изменениями и выполните операцию **push**;
16. Сделайте **pull request** с изменениями из **feature/txt-file** в ветку из шага 12;
17. Выполните **merge**;
18. Сделайте **pull request** в **LES-1/TASK-1-git-practice**;
    В ***Reviewers*** укажите своего куратора. ***Assignees*** - себя. 
