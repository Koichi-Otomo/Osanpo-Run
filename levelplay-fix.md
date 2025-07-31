# Unity LevelPlay エラー修正

## エラーの原因
- Unity LevelPlay パッケージがインストールされている
- IronSource SDK が見つからない
- 不要な広告パッケージが残存

## 解決方法

### 1. LevelPlayパッケージを削除
```
Window → Package Manager → In Project
→ "Unity LevelPlay" を選択 → Remove
```

### 2. 関連ファイルを削除
```
Assets/Scripts/Editor/LevelPlay* (あれば削除)
Assets/Plugins/iOS/IronSource* (あれば削除)
```

### 3. External Dependency Manager設定
```
Assets → External Dependency Manager → iOS Resolver → Settings
→ "Cocoapods Integration" を "None" に設定
```

### 4. ビルドフォルダをクリーン
```
built program フォルダを削除
Unity → Build Settings → Clean Build
```

### 5. 再ビルド実行

## 予防策
不要な広告関連パッケージを削除：
- Advertisement Legacy
- Unity LevelPlay  
- Mobile Notifications
- External Dependency Manager

## 確認
ビルド時に IronSource 関連エラーが出なければ成功