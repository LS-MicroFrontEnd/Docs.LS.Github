# Use Git and Git Hub
Comands to use when work with git and github


# Sincronize when you create a repository

First, create a new repository in Git Hub like this tutorial
https://docs.github.com/es/github/creating-cloning-and-archiving-repositories/creating-a-new-repository

Before this you con do:

1) Open the console, in the local repository folder and put 
- git init

2) Then charge the files in to local storage
- git add .

3) Do a commit 
- git commit -m "First commit"
(whith "" the comment)
(on "" you put the comments of the commits)

4) Put the remote repository URL
- git remote add origin "remote repository URL"
(whitout "" the url)

4.1) See the remote repository URL
- git remote -v

5) Finish push the change in the remote repository
- git push origin main
