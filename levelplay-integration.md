# LevelPlay SDK統合手順

## 1. 初期化の配置場所

### **TitleScene（推奨）**
- `LevelPlayManager.cs`をTitleSceneに配置
- ゲーム開始時に一度だけ初期化
- DontDestroyOnLoadで全シーンで利用可能

### **理由**
- ゲーム開始時の初期化が自然
- ユーザーがゲームを開始する前に準備完了
- 他のシーンで広告表示時にすぐ利用可能

## 2. Unity側での設定

### **TitleSceneに追加**
1. TitleSceneを開く
2. 空のGameObjectを作成
3. `LevelPlayManager.cs`をアタッチ
4. App Keyを設定

### **各シーンでの広告表示**
- `AdManager.cs`が各シーンで広告表示を担当
- LevelPlayManagerで初期化済みのSDKを使用

## 3. App Key設定
```csharp
[SerializeField] private string appKey = "ThisIsYourAppKey";
```
実際のApp KeyをLevelPlayManagerに設定してください。

## 4. 動作フロー
1. TitleScene起動
2. LevelPlayManager初期化
3. SDK初期化完了
4. 他シーンで広告表示可能

## 5. 確認方法
- コンソールで「LevelPlay初期化成功」を確認
- 広告表示時にエラーが出ないことを確認