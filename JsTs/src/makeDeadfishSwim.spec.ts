import { assert } from "chai";
import { parse } from "./makeDeadfishSwim";

describe("deadfish", function () {
  it("test", function () {
    assert.deepEqual(parse("iiisdoso"), [8, 64]);
    assert.deepEqual(parse("iiisxxxdoso"), [8, 64]);
  });
});
