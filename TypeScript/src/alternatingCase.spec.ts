import { toAlternatingCase } from "./alternatingCase";
import { assert } from "chai";

describe("alternating case <-> alternating case", function () {
  it("should return a reversed case value", function () {
    assert.equal(toAlternatingCase("hello world"), "HELLO WORLD");
    assert.equal(toAlternatingCase("HeLLo WoRLD"), "hEllO wOrld");
    assert.equal(toAlternatingCase("1a2b3c4d5e"), "1A2B3C4D5E");
  });
});
