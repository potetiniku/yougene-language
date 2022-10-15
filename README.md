# ユージェネ言語インタプリタ

ユージェネ言語インタプリタは、ユージェネ言語の実行環境です。  
(最初にコードの全てをパースしているので、「インタプリタ」と呼ぶには微妙ですが)

## ユージェネ言語とは!

ユージェネ言語は、株式会社コロプラのサービスである「ユージェネライブ」に登場するキャラクター(アスタリスタ)のセリフをもとにした、Brainfuckの派生言語です。

~~この名前はなんとかならなかったのか~~

### 言語仕様

Brainfuckで使われる記号の代わりに、アスタリスタのセリフを使います。  
ホワイトスペースは無視されます。また、下記の命令以外がコードに含まれていると正しく実行できません。

| Brainfuck | ユージェネ言語                   |
| --------- | -------------------------------- |
| >         | ポチ                             |
| <         | capa                             |
| +         | もん!                            |
| -         | ちゃんか                         |
| .         | だし!                            |
| ,         | 安直だね～                       |
| [         | あ!今お蕎麦のエール貰っちゃった! |
| ]         | アニャちゃんそれうどんだよ!      |

## 使い方

ユージェネ言語のソースコードを実行するには、以下のコマンドを実行します。

```
.\yg.exe <ソースファイル>
```

### 例

```
.\yg.exe example.yg
```