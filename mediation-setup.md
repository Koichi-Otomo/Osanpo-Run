# Unity Ads Mediation セットアップ手順

## 1. パッケージインストール
```
Window → Package Manager → Unity Registry
- Advertisement Legacy
```

**注意**: Unity Ads Mediationパッケージが利用できない場合は、従来のUnity Adsを使用します。

## 2. Unity Dashboard設定
1. Unity Dashboard → Ads → Mediation
2. 新しいプロジェクト作成
3. Game ID: `9ec87949-3c6b-4e48-83cb-fd39f6363cfa`

## 3. Ad Unit作成
1. Mediation → Ad Units → Create Ad Unit
2. Type: Interstitial
3. Platform: iOS/Android
4. Ad Unit ID: `0ri0c3pbzi4j25u5`

## 4. 広告ネットワーク追加
### Unity Ads
- App ID: `9ec87949-3c6b-4e48-83cb-fd39f6363cfa`
- Placement ID: `Interstitial_iOS` / `Interstitial_Android`

### Google AdMob (推奨)
- App ID: ca-app-pub-xxxxxxxxxxxxxxxx~xxxxxxxxxx
- Ad Unit ID: ca-app-pub-xxxxxxxxxxxxxxxx/xxxxxxxxxx

### Facebook Audience Network
- App ID: Facebook App ID
- Placement ID: Facebook Placement ID

## 5. ウォーターフォール設定
1. Mediation → Waterfall
2. 広告ネットワークの優先順位設定
3. eCPM値に基づく自動最適化

## 6. テスト設定
- Test Mode: 有効
- Test Device追加

## 7. 収益最大化のポイント
- 複数ネットワーク統合
- リアルタイム入札対応
- A/Bテスト実施