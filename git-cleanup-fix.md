# Git大容量ファイル削除手順

## 問題
- Libraryフォルダの大容量ファイルがGit履歴に残存
- GitHubの100MB制限に引っかかる

## 解決方法

### 1. BFG Repo-Cleanerインストール
```bash
brew install bfg
```

### 2. リポジトリのクリーンアップ
```bash
# 現在のディレクトリで実行
bfg --delete-folders Library
bfg --delete-folders "built program"
```

### 3. Gitの履歴を書き換え
```bash
git reflog expire --expire=now --all
git gc --prune=now --aggressive
```

### 4. 強制プッシュ
```bash
git push --force-with-lease origin main
```

## 代替案：新しいリポジトリ作成

### 1. 現在のファイルをバックアップ
```bash
cp -r Assets ~/Desktop/Osanpo-Run-backup/
cp -r ProjectSettings ~/Desktop/Osanpo-Run-backup/
cp .gitignore ~/Desktop/Osanpo-Run-backup/
```

### 2. 新しいリポジトリ初期化
```bash
rm -rf .git
git init
git add Assets/ ProjectSettings/ .gitignore
git commit -m "Initial commit - clean repository"
git remote add origin https://github.com/Koichi-Otomo/Osanpo-Run.git
git push --force origin main
```

推奨：代替案（新しいリポジトリ作成）が最も確実です。