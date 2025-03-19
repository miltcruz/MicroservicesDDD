const nextConfig = {
  async rewrites() {
    return [
      {
        source: "/api/:path*",
        destination: `${process.env.NEXT_PUBLIC_API_BASE_URL}/:path*`, // Dynamically use the environment variable
      },
    ];
  },
};

export default nextConfig;