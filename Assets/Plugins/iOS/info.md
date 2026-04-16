# SKAdNetwork設定手順

## 1. Unity設定
1. `SKAdNetworkIds.plist`を`Assets/Plugins/iOS/`フォルダに移動
2. Build Settings → iOS → Player Settings → Publishing Settings
3. 「Automatically add SKAdNetwork identifiers」にチェック

## 2. 手動設定（必要に応じて）
Xcodeプロジェクトの`Info.plist`に以下を追加：

```xml
<key>SKAdNetworkItems</key>
<array>
    <dict>
        <key>SKAdNetworkIdentifier</key>
        <string>4dzt52r2t5.skadnetwork</string>
    </dict>
    <!-- 他のIDも同様に追加 -->
</array>
```

## 3. 主要広告ネットワークのSKAdNetwork ID

| ネットワーク | SKAdNetwork ID |
|-------------|----------------|
| Unity Ads | 4dzt52r2t5.skadnetwork |
| Google AdMob | cstr6suwn9.skadnetwork |
| Facebook | v9wttpbfk9.skadnetwork |
| ironSource | su67r6k2v3.skadnetwork |
| AppLovin | ludvb6z3bs.skadnetwork |
| Vungle | gta9lk7p23.skadnetwork |

## 4. 月次更新チェックリスト
- [ ] Unity Mediation Dashboard確認
- [ ] 各広告ネットワークの公式ドキュメント確認
- [ ] 新しいSKAdNetwork ID追加
- [ ] アプリ更新時にplist更新

## 5. 収益最大化のポイント
- 全ての使用する広告ネットワークのIDを含める
- iOS 14.5以降のATT（App Tracking Transparency）対応
- 定期的なID更新で最新の広告配信を確保