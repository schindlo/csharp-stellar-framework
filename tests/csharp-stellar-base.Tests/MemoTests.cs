﻿using Xunit;
using Stellar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_stellar_base.Tests
{
    public class MemoTests
    {
        [Fact]
        public void TestMemoNone()
        {
            Memo memo = Memo.MemoNone();

            Assert.Equal(Memo.MemoTypeEnum.MEMO_NONE, memo.Type);

            Stellar.Generated.Memo genMemo = memo.ToXDR();

            Assert.Equal(Stellar.Generated.MemoType.MemoTypeEnum.MEMO_NONE, genMemo.Discriminant.InnerValue);

            Memo resMemo = Memo.FromXDR(genMemo);

            Assert.Equal(Memo.MemoTypeEnum.MEMO_NONE, resMemo.Type);
        }

        [Fact]
        public void TestMemoText()
        {
            string text = "Test";
            Memo memo = Memo.MemoText(text);

            Assert.Equal(text, memo.Text);
            Assert.Equal(Memo.MemoTypeEnum.MEMO_TEXT, memo.Type);

            Stellar.Generated.Memo genMemo = memo.ToXDR();

            Assert.Equal(text, genMemo.Text);
            Assert.Equal(Stellar.Generated.MemoType.MemoTypeEnum.MEMO_TEXT, genMemo.Discriminant.InnerValue);

            Memo resMemo = Memo.FromXDR(genMemo);

            Assert.Equal(text, resMemo.Text);
            Assert.Equal(Memo.MemoTypeEnum.MEMO_TEXT, resMemo.Type);
        }

        [Fact]
        public void TestMemoTextNull()
        {
            var ex = Assert.Throws<NullReferenceException>(() => Memo.MemoText(null));
            Assert.Equal(ex.Message, "textorhash cannot be null.");
        }

        [Fact]
        public void TestMemoId()
        {
            long id = 1234567890;
            Memo memo = Memo.MemoId(id);

            Assert.Equal(id, memo.Id);
            Assert.Equal(Memo.MemoTypeEnum.MEMO_ID, memo.Type);

            Stellar.Generated.Memo genMemo = memo.ToXDR();

            Assert.Equal(new Stellar.Generated.Uint64((ulong)id).InnerValue, genMemo.Id.InnerValue);
            Assert.Equal(Stellar.Generated.MemoType.MemoTypeEnum.MEMO_ID, genMemo.Discriminant.InnerValue);

            Memo resMemo = Memo.FromXDR(genMemo);

            Assert.Equal(id, resMemo.Id);
            Assert.Equal(Memo.MemoTypeEnum.MEMO_ID, resMemo.Type);
        }

        [Fact]
        public void TestMemoIdNegative()
        {
            var ex = Assert.Throws<ArgumentException>(() => Memo.MemoId(-1));
            Assert.Equal(ex.Message, "id must be non-negative.");
        }

        [Fact]
        public void TestMemoHash()
        {
            string hash = "TestHashTestHashTestHashTestHash";
            Memo memo = Memo.MemoHash(hash);

            Assert.Equal(hash, memo.Hash);
            Assert.Equal(Memo.MemoTypeEnum.MEMO_HASH, memo.Type);

            Stellar.Generated.Memo genMemo = memo.ToXDR();

            Assert.Equal(Encoding.ASCII.GetBytes(hash).ToString(), genMemo.Hash.InnerValue.ToString());
            Assert.Equal(Stellar.Generated.MemoType.MemoTypeEnum.MEMO_HASH, genMemo.Discriminant.InnerValue);

            Memo resMemo = Memo.FromXDR(genMemo);

            Assert.Equal(hash, resMemo.Hash);
            Assert.Equal(Memo.MemoTypeEnum.MEMO_HASH, resMemo.Type);
        }

        [Fact]
        public void TestMemoHashNone()
        {
            var ex = Assert.Throws<NullReferenceException>(() => Memo.MemoHash(null));
            Assert.Equal(ex.Message, "textorhash cannot be null.");
        }

        [Fact]
        public void TestMemoHashWrong()
        {
            var ex = Assert.Throws<ArgumentException>(() => Memo.MemoHash("Wrong"));
            Assert.Equal(ex.Message, "Invalid hash.");
        }

        [Fact]
        public void TestMemoReturnHash()
        {
            string retHash = "TestHashTestHashTestHashTestHash";
            Memo memo = Memo.MemoReturnHash(retHash);

            Assert.Equal(retHash, memo.RetHash);
            Assert.Equal(Memo.MemoTypeEnum.MEMO_RETURN, memo.Type);

            Stellar.Generated.Memo genMemo = memo.ToXDR();

            Assert.Equal(Encoding.ASCII.GetBytes(retHash).ToString(), genMemo.RetHash.InnerValue.ToString());
            Assert.Equal(Stellar.Generated.MemoType.MemoTypeEnum.MEMO_RETURN, genMemo.Discriminant.InnerValue);

            Memo resMemo = Memo.FromXDR(genMemo);

            Assert.Equal(retHash, resMemo.RetHash);
            Assert.Equal(Memo.MemoTypeEnum.MEMO_RETURN, resMemo.Type);
        }

        [Fact]
        public void TestMemoReturnHashNone()
        {
            var ex = Assert.Throws<NullReferenceException>(() => Memo.MemoReturnHash(null));
            Assert.Equal(ex.Message, "textorhash cannot be null.");
        }

        [Fact]
        public void TestMemoReturnHashWrong()
        {
            var ex = Assert.Throws<ArgumentException>(() => Memo.MemoReturnHash("Wrong"));
            Assert.Equal(ex.Message, "Invalid retHash.");
        }
    }
}
