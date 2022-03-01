import { assert } from "chai";
import { Kata } from "./highestAndLowest";

describe("highest and lowest", () => {
  it("works with one number", () => {
    assert.strictEqual(Kata.highAndLow("5"), "5 5");
  });

  it("works with three numbers", () => {
    assert.strictEqual(Kata.highAndLow("1 2 3"), "3 1");
  });

  it("works with many numbers", () => {
    assert.strictEqual(
      Kata.highAndLow("8 3 -5 42 -1 0 0 -9 4 7 4 -4"),
      "42 -9"
    );
  });
});
