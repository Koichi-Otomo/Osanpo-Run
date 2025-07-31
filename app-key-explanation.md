# LevelPlay App Key について

## App Keyとは
- **IronSource（LevelPlay）のアプリケーション識別子**
- アプリを一意に識別するための文字列
- 広告収益化プラットフォームへの接続に必要

## App Keyの取得方法

### 1. IronSource Dashboardにアクセス
```
https://platform.ironsrc.com/
```

### 2. アカウント作成・ログイン
- 新規アカウント作成またはログイン
- 開発者情報を登録

### 3. アプリ追加
1. Dashboard → Apps → Add App
2. Platform: iOS/Android選択
3. App Name: "Osanpo-Run"
4. Bundle ID: com.yourcompany.osanporun

### 4. App Key取得
- アプリ作成後、App Keyが表示される
- 形式例: `1a2b3c4d`（8桁の英数字）

## 現在の設定値
```csharp
private string appKey = "ThisIsYourAppKey"; // プレースホルダー
```

## 実際の設定例
```csharp
private string appKey = "1a2b3c4d"; // 実際のApp Key
```

## Unity Ads Game IDとの違い
- **Unity Ads Game ID**: `9ec87949-3c6b-4e48-83cb-fd39f6363cfa`
- **IronSource App Key**: `1a2b3c4d`（例）

## 注意点
- App Keyは公開しても問題ない（クライアント側で使用）
- iOS/Android別々のApp Keyが必要
- テスト用とプロダクション用で異なる場合がある