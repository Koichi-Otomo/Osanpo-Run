# 最適化されたシェル設定

## 現在の問題点
- `eval "$(rbenv init -)"` が3回重複
- PATHの重複設定
- 不要なパス設定

## 最適化版（~/.zshrcに追加）

```bash
# Python (pyenv)
eval "$(pyenv init -)"
export PATH="/opt/homebrew/opt/python@3.13/libexec/bin:$PATH"

# Ruby (rbenv) - 一度だけ設定
export PATH="$HOME/.rbenv/bin:$PATH"
eval "$(rbenv init -)"

# Ruby gems (現在のRubyバージョンに自動対応)
export PATH="$(ruby -e 'puts Gem.user_dir')/bin:$PATH"
```

## 設定適用
```bash
source ~/.zshrc
```

## 確認コマンド
```bash
echo $PATH
ruby -v
which ruby
which pod
```

## 削除すべき重複行
- `eval "$(rbenv init -)"` の重複
- `/Users/otomo-k/.rbenv/shims/ruby/3.3.0/bin` (存在しないパス)
- `$HOME/.gem/ruby/3.3.0/bin` の重複

## 結果
- PATH設定がシンプルに
- Rubyバージョン変更時も自動対応
- 重複による競合を回避