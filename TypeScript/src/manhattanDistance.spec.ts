// See https://www.chaijs.com for how to use Chai.
import { assert } from "chai";
import { manhattanDistance } from "./manhattanDistance";

describe("Manhattan distance", () => {
  it("Sample tests", () => {
    assert.equal(manhattanDistance([1, 1], [1, 1]), 0);
    assert.equal(manhattanDistance([5, 4], [3, 2]), 4);
    assert.equal(manhattanDistance([1, 1], [0, 3]), 3);
  });
});
