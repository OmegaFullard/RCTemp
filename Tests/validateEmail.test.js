import { validateEmail } from "./validateEmail";

describe("validateEmail", () => {
    test("returns true for a valid email", () => {
        expect(validateEmail("example@test.com")).toBe(true);
    });

    test("returns false for an invalid email format", () => {
        expect(validateEmail("not-an-email")).toBe(false);
        expect(validateEmail("missing@domain")).toBe(false);
        expect(validateEmail("@missingusername.com")).toBe(false);
    });

    test("returns false for empty or null values", () => {
        expect(validateEmail("")).toBe(false);
        expect(validateEmail(null)).toBe(false);
        expect(validateEmail(undefined)).toBe(false);
    });

    test("returns false for non-string values", () => {
        expect(validateEmail(123)).toBe(false);
        expect(validateEmail({ email: "test@test.com" })).toBe(false);
        expect(validateEmail(["test@test.com"])).toBe(false);
    });
});