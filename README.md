# Use Git and Git Hub
### Important "main" and "master" are names of defaults branch, before we used master but now we use main like default branch
### First downloand [Git](https://git-scm.com/downloads)
# Sincronize when you create a repository

First, [Create a new repository](https://docs.github.com/es/github/creating-cloning-and-archiving-repositories/creating-a-new-repository) in Git Hub 

After this, you should do:


1) Open the console, in the local repository folder and add .git 
```
git init
```
2) Add the remote repository URL
```
git remote add origin "remote repository URL"
```
- (whitout "" the url)
- (the url is like this https://github.com/CarlosLopezSoto/UseGit)

3) Check the remote repository URL
```
git remote -v
```
4) Create a branch 
```
git checkout -b "name brach" 
```
- (whitout "" the name branch)
- (when is the first branch, the name is main)

More info:
[Check Out tutorils](https://www.atlassian.com/es/git/tutorials/using-branches/git-checkout)

5) Pull all files from the remote repository
```
git pull origin "name branch"
```

### Same cases
**If you did a pull when the local repository and the remote repository has diferents files return error **
```
git pull origin "name brach" --allow-unrelated-histories
```
- This is force to merge those repositories

More info:
[Error when your merge](https://www.educative.io/edpresso/the-fatal-refusing-to-merge-unrelated-histories-git-error)

**If have the error "Name is too long"**
```
git config --system core.longpaths true
```
# Push yours commits into remote repository
1)Charge the files in to local storage
```
git add .
```
2) Do a commit 
```
git commit -m "First commit"
```
- (whith "" the comment)
- (on "" you add the comments of the commits)

3) Finish push the change in the remote repository
```
git push origin main
```
