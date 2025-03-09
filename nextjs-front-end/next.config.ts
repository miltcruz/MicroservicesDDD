import type { NextConfig } from "next";

const nextConfig: NextConfig = {
  async rewrites() {
    return [
      {
        source: '/api/:path*', // Matches any request to /api/* from the frontend
        destination: 'http://localhost:5041/api/:path*', // Redirects to your backend API
      },
    ];
  },
};

export default nextConfig;