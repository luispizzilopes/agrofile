export default function getRootColor(color: string) {
    return getComputedStyle(document.documentElement).getPropertyValue(color);
  }
  