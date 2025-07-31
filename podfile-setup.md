# Podfile設定手順

## 1. Podfileの配置
- `Assets/Plugins/iOS/Podfile`に配置済み
- IronSourceUnityAdsAdapter 4.3.53.0を追加

## 2. Unity設定
```
Build Settings → iOS → Player Settings
→ Publishing Settings
→ "Automatically add SKAdNetwork identifiers" ✓
```

## 3. External Dependency Manager設定
```
Assets → External Dependency Manager → iOS Resolver → Settings
→ "Cocoapods Integration" を "Xcode Project" に設定
→ "Use project settings" ✓
```

## 4. ビルド時の処理
1. Unity → Build Settings → Build
2. Xcodeプロジェクト生成後、自動的にCocoaPodsが実行される
3. `pod install`が自動実行されてIronSourceが統合される

## 5. 手動でCocoaPods実行する場合
```bash
cd "built program"
pod install
```

## 6. 確認方法
- Xcodeで`Unity-iPhone.xcworkspace`を開く
- Pods/IronSourceUnityAdsAdapterが存在することを確認

## 注意点
- `.xcworkspace`ファイルを使用（`.xcodeproj`ではない）
- iOS 12.0以上が必要