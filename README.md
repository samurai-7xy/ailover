# ailover
課題研究『AI彼氏』用のリポジトリです

## 概要
AIと恋人として会話できるサイトです。



```mermaid
sequenceDiagram
    autonumber
    actor a as ユーザー
    participant enzin as エンジン
    participant output as GPT
    participant audio as VOICE VOX
    participant live as LIVE 2D

    rect rgba(253, 231, 253, 0.4)
    a ->> enzin: メッセージテキスト
    end
    rect rgba(253, 231, 253, 0.4)
    enzin ->> output: メッセージテキスト
    end
    rect rgba(253, 231, 253, 0.4)
    output ->> audio: レスポンステキスト
    end
    rect rgba(253, 231, 253, 0.4)
    audio ->> live: レスポンスWAV
    end
    rect rgba(231, 253, 242, 0.4)
    live -->> enzin: モデル
    end
    rect rgba(231, 253, 242, 0.4)
    audio -->> enzin: レスポンスWAV
    end
    rect rgba(231, 253, 242, 0.4)
    output -->> enzin: レスポンステキスト
    end
    rect rgba(231, 253, 242, 0.4)
    enzin -->> a: 
    end

    ##253, 231, 253, 0.4 ピンク系
    ##231, 253, 242, 0.4 緑系
    

```