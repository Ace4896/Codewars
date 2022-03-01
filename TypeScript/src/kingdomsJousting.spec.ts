import { assert } from "chai";
import { joust } from "./kingdomsJousting";

describe("Sample jousting", function () {
  it(`given ["$->    ", "    <-P"], 1, 1`, function () {
    assert.deepEqual(joust(["$->    ", "    <-P"], 1, 1), [
      " $->   ",
      "   <-P ",
    ]);
  });
  it(`given ["$->     ", "     <-P"], 1, 1`, function () {
    assert.deepEqual(joust(["$->     ", "     <-P"], 1, 1), [
      "  $->   ",
      "   <-P  ",
    ]);
  });
  it(`given ["$->              ", "              <-P"], 1, 1`, function () {
    assert.deepEqual(joust(["$->              ", "              <-P"], 1, 1), [
      "      $->        ",
      "        <-P      ",
    ]);
  });
});

describe("Sample jousting with different velocity", function () {
  it(`given ["$->    ", "    <-P"], 3, 3`, function () {
    assert.deepEqual(joust(["$->    ", "    <-P"], 3, 3), [
      "   $-> ",
      " <-P   ",
    ]);
  });
  it(`given ["$->   ", "   <-P"], 3, 3`, function () {
    assert.deepEqual(joust(["$->   ", "   <-P"], 3, 3), ["   $->", "<-P   "]);
  });
  it(`given ["$->     ", "     <-P"], 0, 2`, function () {
    assert.deepEqual(joust(["$->     ", "     <-P"], 0, 2), [
      "$->     ",
      " <-P    ",
    ]);
  });
  it(`given [ "$->              ", "              <-P"], 2, 3`, function () {
    assert.deepEqual(joust(["$->              ", "              <-P"], 2, 3), [
      "      $->        ",
      "     <-P         ",
    ]);
  });
});

describe("Immediate battle", function () {
  it(`given ["$->  ", "  <-P"], 3, 3`, function () {
    assert.deepEqual(joust(["$->  ", "  <-P"], 3, 3), ["$->  ", "  <-P"]);
  });
  it(`given ["$->", "<-P"], 3, 3`, function () {
    assert.deepEqual(joust(["$->", "<-P"], 3, 3), ["$->", "<-P"]);
  });
  it(`given ["$-> ", " <-P"], 0, 0`, function () {
    assert.deepEqual(joust(["$-> ", " <-P"], 0, 0), ["$-> ", " <-P"]);
  });
});

describe("Knights refused to fight", function () {
  it(`given ["$->    ", "    <-P"], 0, 0`, function () {
    assert.deepEqual(joust(["$->    ", "    <-P"], 0, 0), [
      "$->    ",
      "    <-P",
    ]);
  });
});
