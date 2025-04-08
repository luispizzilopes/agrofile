import { NextRequest, NextResponse } from "next/server";

export async function middleware(request: NextRequest) {
    const token = request.cookies.get("token-agro-file");

    const protectedRoutes = ["/home", "/users"];
    const isProtectedRoute = protectedRoutes.includes(request.nextUrl.pathname);

    if (isProtectedRoute && !token) {
        return NextResponse.redirect(new URL("/login", request.url));
    }

    return NextResponse.next();
}