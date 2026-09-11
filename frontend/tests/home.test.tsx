import { render, screen } from "@testing-library/react";
import { describe, expect, it } from "vitest";
import Home from "../src/app/page";

describe("Home", () => {
  it("renders the application heading", () => {
    render(<Home />);

    expect(
      screen.getByRole("heading", { name: "CaseFlow" }),
    ).toBeInTheDocument();
  });
});
